//
//  main.cpp
//  assign_05
//
//  Created by Youchen Ren on 6/14/14.
//
#include <iostream>
#include <cstdlib>
#include <fstream>
#include "Polynomial.h"
using namespace std;

int main(int argc, const char * argv[])
{
    
    
    //    //create and print a list of n integer nodes
    //    int n;
    //    cout<<"How many nodes? ";
    //    cin>>n;
    //    cout<<endl;
    //
    //    print_list(make_int_list(n));
    //    cout<<endl;
    //
    //    //now do it recursively
    //    print_list_rec(make_int_list(n));
    //    cout<<endl;
    //
    //    node* a = make_int_list(9);
    //    node* b = new node(56, 28);
    //
    //    add_at_end(a,b);
    //    cout<<endl;
    //
    //    cout << "print LL a: \n";
    //    print_list(a);
    //
    //    cout << "String Poly: ===============\n";
    //    Polynomial strPoly = *new Polynomial("5x^4 + 3x^3");
    
    
    string inputStr;
	ofstream output;
    
    ifstream input (argv[1]);
    output.open (argv[2]);
    
    if (argc < 3) { //first argument(argv[0]) is the program path
		cerr << "usage: " << argv[0] << " <input file> <dest file>" << endl;
		return 0;
	}
    
    while ( input.good() ){
        getline (input,inputStr);
        if(!inputStr.empty()){
            output << "original 1: " << inputStr << endl;
            
            Polynomial a(inputStr);
            getline (input,inputStr);
            
            Polynomial b(inputStr);
            
            output << "original 2: " << inputStr;
            output << endl;
            output << "canonical 1: " << a;
            output << "canonical 2: " << b;
            output << "sum: " << a+b;
            output << "difference: " << a-b;
            output << "product: " << a*b;
            output << endl;
        }
    }
    input.close();
    output.close();
    return 0;
}
