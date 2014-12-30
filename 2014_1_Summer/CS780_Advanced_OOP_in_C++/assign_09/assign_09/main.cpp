//
//  main.cpp
//  assign_09
//
//  Created by Youchen Ren on 6/23/14.
//  Copyright (c) 2014 Youchen Ren. All rights reserved.
//
#include <cstdlib>
#include <iostream>
#include <map>
#include <string>
#include <fstream>
#include <sstream>
using namespace std;

int strtoint(string str){
    int integer;
    istringstream(str) >> integer;
    return integer;
}

//Polynomial addition using maps
int main(int argc, char *argv[]){
    
    
    
    
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
            
            //===================================================
            Polynomial(string equation){
                string val_1, val_2;
                head = new node();
                istringstream trim(equation);
                
                while (trim >> val_1 >> val_2) {
                    append(strtoint(val_1), strtoint(val_2));
                }
                
            }
            //===================================================
            
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
    
    
    
    
    
    
    
    map<int,int> poly1, poly2, sum;
    int c,e;
    string val_1, val_2;
    
    while ( input.good() ){
        getline (input,inputStr);
        //when ther IS concrete line catched.
        if(!inputStr.empty()){
            output << "original 1: " << inputStr << endl;
//            string val_1, val_2;
            istringstream trim(inputStr);
            //this will read the first polynomial, and automatically
            //keep in "reverese cannonical form"======================poly 1===
            while (trim >> val_1 >> val_2) {
                c = strtoint(val_1);
                e = strtoint(val_2);
                poly1[e] += c;
                if(poly1[e] == 0)
                    poly1.erase(e);
            }//while trim >> val_1
            
            // print poly 1 in cannonical form
            map<int,int>:: reverse_iterator p;
            for(p = poly1.rbegin(); p != poly1.rend(); p++) {
                cout << (*p).second << " " << (*p).first << endl;
            }
            cout << endl << "this was the first polynomial" << endl;
            
            //=============for poly 2===================================
            getline (input,inputStr);
            output << "original 2: " << inputStr << endl;
            istringstream trim2(inputStr);
            //this will read the 2nd polynomial, and automatically
            //keep in "reverese cannonical form"
            while (trim2 >> val_1 >> val_2) {
                c = strtoint(val_1);
                e = strtoint(val_2);
                poly2[e] += c;
                if(poly2[e] == 0)
                    poly2.erase(e);
            }//while trim >> val_1
            
            // print poly 2 in cannonical form
            map<int,int>:: reverse_iterator pp;
            for(pp = poly2.rbegin(); pp != poly2.rend(); pp++) {
                cout << (*pp).second << " " << (*pp).first << endl;
            }
            cout << endl << "this was the second polynomial" << endl;
            
            /*
             Operation for poly 1 and poly 2.
             */
            
            
            
            
        
        }//if !inputStr
    }//while input.good
    
    
    
    
//    for(int i = 0; i < 4; i++ ){
//        cin >> c >> e;
//        poly1[e] += c;
//        if(poly1[e] == 0)
//            poly1.erase(e);
//    }
    
    // print poly 1 in cannonical form
    map<int,int>:: reverse_iterator p;
    for(p = poly1.rbegin(); p != poly1.rend(); p++) {
        cout << (*p).second << " " << (*p).first << endl;
    }
    cout << endl << "this was the first polynomial" << endl;
    
    //read the 2nd poly=======================================poly 2===
    for(int i = 0;i < 4; i++){
        cin >> c >> e;
        poly2[e] += c;
        if(poly2[e] == 0)
            poly2.erase(e);
    }
    
    // print poly 2 in cannonical form
    map<int,int>:: reverse_iterator pp;
    for(pp = poly2.rbegin(); pp != poly2.rend(); pp++) {
        cout << (*pp).second << " " << (*pp).first << endl;
    }
    cout << endl << "this was the second polynomial" << endl;
    
    // now "add poly2 to sum===================================sum ====
    sum = poly1;
    for( p = poly2.rbegin(); p != poly2.rend(); p++) {
        sum[ p->first ] += p->second;
        if( sum[p->first] == 0)
            sum.erase( p->first );
    }
    // print the sum of poly1 + poly2
    for(p = sum.rbegin(); p != sum.rend(); p++) {
        cout<< (*p).second << " " << (*p).first << endl;
    }
    
    
    
    
    input.close();
    output.close();
    system("PAUSE");
    return EXIT_SUCCESS;
}
