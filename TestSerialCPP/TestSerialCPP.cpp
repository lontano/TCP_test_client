// TestSerialCpp.cpp : Este archivo contiene la función "main". La ejecución del programa comienza y termina ahí.
//
#include "pch.h"
#include "stdafx.h"

#include <ctime>

#include <iostream>
#include <sys/timeb.h>



#include <sys/types.h>
#include <sys/types.h>
#include <memory.h>
#include <errno.h>
#include <stdlib.h>
#include <iostream>
#include <WinSock2.h>
#include <WS2tcpip.h>

#pragma comment (lib, "ws2_32.lib")

int getMilliCount() {
	timeb tb;
	ftime(&tb);
	int nCount = tb.millitm + (tb.time & 0xfffff) * 1000;
	return nCount;
}

int getMilliSpan(int nTimeStart) {
	int nSpan = getMilliCount() - nTimeStart;
	if (nSpan < 0)
		nSpan += 0x100000 * 1000;
	return nSpan;
}
void error_de_sistema(const char *name) {
	// Recupera, formatea y despliega el mensaje del ultimo error
	// 'name' que es el argumento pasado al momento del error debe ser una     frase en presente
	//  como por ejemplo "abriendo archivo".
	//
	//char *ptr = NULL;
	WCHAR ptr[1024];
	FormatMessage(
		FORMAT_MESSAGE_ALLOCATE_BUFFER |
		FORMAT_MESSAGE_FROM_SYSTEM,
		0,
		GetLastError(),
		0,
		//(char *)&ptr,
		ptr,
		1024,
		NULL);
	//fprintf(stderr, "\nError %s: %s\n", name, ptr);
	//fprintf(stderr, "\nError %s: %s\n", name, &ptr);
	wcout << endl << "Error " << name << ": " << ptr << endl;
	LocalFree(ptr);
}


int resolvehelper(const char* hostname, int family, const char* service, sockaddr_storage* pAddr)
{
	int result;
	addrinfo* result_list = NULL;
	addrinfo hints = {};
	hints.ai_family = family;
	hints.ai_socktype = SOCK_DGRAM; // without this flag, getaddrinfo will return 3x the number of addresses (one for each socket type).
	result = getaddrinfo(hostname, service, &hints, &result_list);
	if (result == 0)
	{
		//ASSERT(result_list->ai_addrlen <= sizeof(sockaddr_in));
		memcpy(pAddr, result_list->ai_addr, result_list->ai_addrlen);
		freeaddrinfo(result_list);
	}

	return result;
}


int _tmain(int argc, _TCHAR* argv[])
{
	int ch = 0;
	char buffer[15];
	HANDLE file;
	COMMTIMEOUTS timeouts;
	DWORD read, written;
	DCB port;
	HANDLE keyboard = GetStdHandle(STD_INPUT_HANDLE);
	HANDLE screen = GetStdHandle(STD_OUTPUT_HANDLE);
	DWORD mode;
	//char port_name[128] = "\\\\.\\COM3";
	LPCWSTR port_name = L"\\\\.\\COM4";
	char init[] = ""; // v.gr., "ATZ" resetea un modem por completo.

	if (argc > 2)
		swprintf_s((wchar_t *)&port_name, 128, L"\\\\.\\COM%c", argv[1][0]);
	//sprintf(port_name, "\\\\.\\COM%c", argv[1][0]);

	// abre el puerto.
	file = CreateFile(port_name,
		GENERIC_READ | GENERIC_WRITE,
		0,
		NULL,
		OPEN_EXISTING,
		0,
		NULL);

	if (INVALID_HANDLE_VALUE == file) {
		error_de_sistema("abriendo archivo");
		return 1;
	}
	printf("\n\Opening COM Port...");
	// obtiene el block de control del dispositivo DCB, y ajusta unos cuantos bits para nuestro enlace.
	memset(&port, 0, sizeof(port));
	port.DCBlength = sizeof(port);
	if (!GetCommState(file, &port))
		error_de_sistema("obteniendo el estado del puerto");
	//if (!BuildCommDCB("baud=19200 parity=n data=8 stop=1", &port))
	if (!BuildCommDCB(L"baud=38400 parity=n data=8 stop=1", &port))
		error_de_sistema("creando el bloque DCB de comunicaciones");
	if (!SetCommState(file, &port))
		error_de_sistema("ajustando la configuracion del puerto");

	// Configura los tiempos fuera cortos para el puerto.
	timeouts.ReadIntervalTimeout = 1;
	timeouts.ReadTotalTimeoutMultiplier = 1;
	timeouts.ReadTotalTimeoutConstant = 1;
	timeouts.WriteTotalTimeoutMultiplier = 1;
	timeouts.WriteTotalTimeoutConstant = 1;
	if (!SetCommTimeouts(file, &timeouts))
		error_de_sistema("configurando los time-outs. del puerto");

	// Configura el teclado para una lectura raw (aleatoria y libre).
	if (!GetConsoleMode(keyboard, &mode))
		error_de_sistema("obteniendo el modo del teclado");
	mode &= ~ENABLE_PROCESSED_INPUT;
	if (!SetConsoleMode(keyboard, mode))
		error_de_sistema("configurando el modo del teclado");

	if (!EscapeCommFunction(file, CLRDTR))
		error_de_sistema("apagando el DTR");
	Sleep(200);
	if (!EscapeCommFunction(file, SETDTR))
		error_de_sistema("encendiendo el DTR");

	if (!WriteFile(file, init, sizeof(init), &written, NULL))
		error_de_sistema("escribiendo datos en el puerto");

	if (written != sizeof(init))
		error_de_sistema("porque no todos los datos se enviaron al puerto");


	//init UDP
	int iResult;
	WSADATA wsaData;

	SOCKET SendSocket = INVALID_SOCKET;
	sockaddr_in RecvAddr;

	unsigned short Port = 27015;

	char SendBuf[1024];
	int BufLen = 1024;

	//----------------------
	// Initialize Winsock
	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != NO_ERROR) {
		wprintf(L"WSAStartup failed with error: %d\n", iResult);
		return 1;
	}

	//---------------------------------------------
	// Create a socket for sending data
	SendSocket = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
	if (SendSocket == INVALID_SOCKET) {
		wprintf(L"socket failed with error: %ld\n", WSAGetLastError());
		WSACleanup();
		return 1;
	}
	//---------------------------------------------
	// Set up the RecvAddr structure with the IP address of
	// the receiver (in this example case "192.168.1.1")
	// and the specified port number.
	RecvAddr.sin_family = AF_INET;
	RecvAddr.sin_port = htons(6000);
	//RecvAddr.sin_addr.s_addr = inet_addr("192.168.1.1");
	PCWSTR host = L"127.0.0.1";
	//PCWSTR host = L"100.100.100.112";
	//RecvAddr.sin_addr.s_addr =  
	InetPton(AF_INET, host, &RecvAddr.sin_addr);


	//Start listening
	printf("\n\nStarting loop...");
	int start = getMilliCount();
	int lastDataTime = getMilliCount();
	int bytesRead = 0;
	int pacektsRead = 0;
	int milliSecondsElapsed = getMilliSpan(start);
	int fullPackets = 0;
	int notRecognicedData = 0;
	// ciclo basico de la terminal:
	char ringBuffer[1024];
	int ringBufferSize = 0;
	do {
		// checa por datos en el puerto y los despliega en pantalla.
		ReadFile(file, buffer, sizeof(buffer), &read, NULL);
		if (read) {
			milliSecondsElapsed = getMilliSpan(lastDataTime);
			lastDataTime = getMilliCount();
			//WriteFile(screen, buffer, read, &written, NULL);
			bytesRead += read;
			if (read == 15 && buffer[0] == 4) {
				fullPackets++;
			}
			else {
				printf("Elapsed time = %u ms; since last %u ms, %d bytes; first byte %d\n", getMilliSpan(start), milliSecondsElapsed, read, buffer[0]);
				notRecognicedData += read;
				/*
				memcpy(&ringBuffer[ringBufferSize], buffer, read);
				ringBufferSize += read;
				if (ringBufferSize == 15 && ringBuffer[0] == 4) {
					fullPackets++;
					ringBufferSize -= 15;
				}*/

			}

			//---------------------------------------------
			   // Send a datagram to the receiver
			wprintf(L"Sending a datagram to the receiver...\n");
			iResult = sendto(SendSocket,
				buffer, read, 0, (SOCKADDR *)& RecvAddr, sizeof(RecvAddr));
			if (iResult == SOCKET_ERROR) {
				wprintf(L"sendto failed with error: %d\n", WSAGetLastError());
				closesocket(SendSocket);
				WSACleanup();
				return 1;
			}
		}
	} while (!_kbhit());    // hasta que el usuario pulse ctrl-backspace.
	milliSecondsElapsed = getMilliSpan(start);
	printf("\n\nElapsed time = %u milliseconds", milliSecondsElapsed);
	printf("\n");
	printf("Bytes read = %u", bytesRead);
	printf("\n");
	printf("Bytes per second = %u", (1000 * bytesRead) / milliSecondsElapsed);
	printf("\n");
	printf("Packets per second = %u", (1000 * bytesRead) / (15 * milliSecondsElapsed));
	printf("\n");
	printf("Time per packet = %u ms", (15 * milliSecondsElapsed) / bytesRead);
	printf("\n");
	printf("Full packets = %u (%d bytes)", fullPackets, fullPackets * 15);
	printf("\n");
	printf("Not recognized data = %u bytes", notRecognicedData);
	printf("\n");


	// cierra todo y bye bye.
	CloseHandle(keyboard);
	CloseHandle(file);
	return 0;
}