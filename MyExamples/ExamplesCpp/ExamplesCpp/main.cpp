#include <iostream>

using namespace std;

class Singleton{
private:
	Singleton(){};
	static Singleton* instance;

public:
	static Singleton* Instance()
	{
		if (instance==NULL)
			instance=new Singleton();
		return instance;
	}

	void show()
	{
		cout<<"All ok"<<endl;
	}
};

Singleton* Singleton::instance=0;

int main()
{

	Singleton::Instance()->show();

	return 0;
}