#include "logic.h"

int main()
{
	setlocale(0, "");
	int choice;
	do {
		system("cls");
		cout << "��� ������ ���� �������� ������ �������:" << endl;
		cout << "1 - ������" << endl;
		cout << "2 - ����" << endl;
		cout << "3 - �����" << endl;
		cin >> choice;
	} while (choice != 1 && choice != 2 && choice != 3);

	if (choice == 1)
	{
		Pet.setname("������");
	}
	if (choice == 2)
	{
		Pet.setname("����");
	}
	if (choice == 3)
	{
		Pet.setname("�����");
	}

	system("cls");
	thread MyThred(Thread);
	for (;;)
	{
		Pet.MainGame();
		Sleep(500);
		system("cls");
	}
	return 0;
}
