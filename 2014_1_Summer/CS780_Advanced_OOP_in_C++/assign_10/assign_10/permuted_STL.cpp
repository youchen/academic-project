//
//  permuted_STL.cpp
//  assign_10
//
//  Created by Youchen Ren on 6/26/14.
//  Copyright (c) 2014 Youchen Ren. All rights reserved.
#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include <map>
using namespace std;

//define two types.
typedef map<int, int> innerMap;
typedef map<string, innerMap> mainMap;

//the entire structure is the map of map.
mainMap dic;//short for dictionary

map<string, innerMap >::iterator it;
map<int, int>::iterator inner_it;

ofstream output;

void dic_print(){
    for (it = dic.begin(); it != dic.end(); ++it) {
        //print the word firstly.
        output << it->first << ": ";
        for (inner_it = (it->second).begin(); inner_it != (it->second).end(); ++inner_it) {
            //print the line number:
            output << (inner_it->first);
            //to see if the prenthesis should be print out.
            //if this line has more than one time occurance of this word,
            //  print the prenthesis.
            if (inner_it->second > 1) {
                output << "(" << inner_it->second << ")";
                //if "," need to print.
                if ( inner_it == --((it->second).end())) {
                }else{
                    output << ", ";
                }
            //else, just print the comma.
            }else{
                if ( inner_it == --((it->second).end())) {
                }else{
                    output << ", ";
                }
            }
        }
        //if this print is not the last printed line for the output,
        //      just print a new line.
        if ( it != (--dic.end())) {
            output << endl;
        }
    }//for
}

int main(int argc, const char * argv[]) {
    
    string inputStr;

    ifstream input (argv[1]);
    output.open (argv[2]);
    
    if (argc < 3) { //first argument(argv[0]) is the program path
		cerr << "usage: " << argv[0] << " <input file> <dest file>" << endl;
		return 0;
	}
    
    int line_num = 0;
    while ( input.good() ){
        getline (input,inputStr);
        //keep tracking the line number after each execution of getline.
        ++line_num;
        //if the line is not empty
        if(!inputStr.empty()){
            string val_1;
            istringstream trim(inputStr);
            //parse the text in this line.
            while (trim >> val_1) {
                dic[val_1][line_num]++;
            }//while trim >> val_1
        }//if ! input.empty()
    }//while input.good()
    
    //print the index.
    dic_print();
    
    input.close();
    output.close();
    return 0;
}
