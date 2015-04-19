
#include <cstdio>

class Class1
{
	void Func1()
	{
		printf("::Class1::Func1()");
	}
};

void GlobalFunction1()
{
	printf("::GlobalFunction1()");
}

void _cdecl CDeclerationFunction()
{
	printf("::CDeclerationFunction()");
}

namespace Namespace1
{	
	class Class2
	{
		void Func2()
		{
			printf("Namespace1::Class2::Func1()");
		}
	};

	void NamespaceFunc2()
	{
		printf("Namespace1::NamespaceFunc2()");
	}
}