
#include "stdafx.h"
#include <iostream>

using namespace std;
void Afisare_vectori(int vec1[], int vec2[], int maxim);
int main()
{
	const int max1 = 5, max2 = 4;
	int v1[max1], v2[max2], i, min,j;
	//Introducem valori in vector 
	for (i = 1; i <= max1; i++)
	{
		cout << "Introduceti valoarea " << i << ":";
		cin >> v1[i];
	}
	// Ordonarea crescatoare a numerelor
	j = 1;
	while (j<=max1) {
		i = 1;
		while (i<=max1) {
			if (v1[i]>v1[i + 1]) 
			{
				min = v1[i];
				v1[i] = v1[i + 1];
				v1[i + 1] = min;
			}
			i++;
		}
		j++;
	}
	Afisare_vectori(v1, v2, max1);
	cin.ignore();
	cin.get();
    return 0;
}
void Afisare_vectori(int vec1[], int vec2[], int maxim)
{
	int i;
	//Afisam primul vector
	cout << "\n\tPrimul vector este";
	for (i = 1; i <= maxim; i++)
	{
		cout << " : " << vec1[i+1];
	}
	//Afisam al doilea vector
	cout << "\n\tVectorul 2 este";
	for (i = 2; i<=maxim; i++)
	{
	vec2[i] = vec1[i + 1];
	cout << " : " << vec2[i];
	}
}


