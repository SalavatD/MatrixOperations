#include "pch.h"

extern "C" __declspec(dllexport) void ToFoldMatrices(double*, double*, int, int, double*);
extern "C" __declspec(dllexport) void MultiplyMatrices(double*, int, int, double*, int, int, double*);
extern "C" __declspec(dllexport) void TransposeMatrix(double*, int, int, double*);

void ToFoldMatrices(double* A, double* B, int n, int m, double* Result)
{
	for (int i = 0; i < n; i++)
		for (int j = 0; j < m; j++)
			*(Result + i * m + j) = *(A + i * m + j) + *(B + i * m + j);
}

void MultiplyMatrices(double* A, int nA, int mA, double* B, int nB, int mB, double* Result)
{
	for (int i = 0; i < nA; i++)
	{
		for (int j = 0; j < mB; j++)
		{
			*(Result + i * mB + j) = 0;
			for (int k = 0; k < mA; k++)
				*(Result + i * mB + j) += *(A + i * mA + k) * *(B + k * mB + j);
		}
	}
}

void TransposeMatrix(double* A, int nA, int mA, double* Result)
{
	for (int i = 0; i < nA; i++)
	{
		for (int j = 0; j < mA; j++)
		{
			*(Result + j * nA + i) = *(A + i * mA + j);
		}
	}
}
