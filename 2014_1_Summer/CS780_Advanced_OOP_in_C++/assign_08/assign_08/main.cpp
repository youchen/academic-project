//
//  main.cpp
//  assign_08
//
//  Created by Youchen Ren on 6/25/14.
//  Copyright (c) 2014 Youchen Ren. All rights reserved.
//

#include <iostream>
#include <fstream>
#include <sstream>
#include <queue>
#include <list>
using namespace std;

class word{
    string name;
    list<int> row;
public:
    word(string n):name(n){
    }
    
    void occur(int row_num) {
        row.push_back(row_num);
    }
    string getName(){
        return name;
    }
    
    int* getRow(){
        int *arr = new int[row.size()];
        int i = 0;
        for (list<int>::iterator it = row.begin(); it != row.end(); ++it) {
            arr[i++] = *it;
        }
        return arr;
    }
    
    int get_row_size(){
        return (int)row.size();
    }
    
    friend ostream& operator<<(ostream& os, word& w){
        os << w.name;
        return os;
    }
};

bool cmp_by_name(word &a, word &b)
{ return a.getName() < b.getName(); }

int main(int argc, const char * argv[]) {
    
    string inputStr;
	ofstream output;
    
    ifstream input (argv[1]);
    output.open (argv[2]);
    
    if (argc < 3) { //first argument(argv[0]) is the program path
		cerr << "usage: " << argv[0] << " <input file> <dest file>" << endl;
		return 0;
	}
    
    int line_num = 0;
    list<word> dictionary;
    
    while ( input.good() ){
        getline (input,inputStr);
        ++line_num;
        //if the line is not empty
        if(!inputStr.empty()){
            
            string val_1;
            istringstream trim(inputStr);
            
            while (trim >> val_1) {
                int iterator_time = 0;
                //if there is no this word in the list, instantiate one in the list.
                if ( dictionary.size() == 0 ) {
                    word new_word(val_1);
                    new_word.occur(line_num);
                    
                    dictionary.push_back(new_word);
                    
                }else{
                    
                    for (list<word>::iterator it = dictionary.begin(); it != dictionary.end(); ++it) {
                        ++iterator_time;
                        //if there is this word in dictionary,
                        //      push the line number on it.
                        if ( ( it -> getName() ).compare( val_1 ) == 0 ) {
                            it -> occur(line_num);
                            break;
                        }
                        //if there is no this word after the entire search,
                        //      just create an object and push onto the dictionary
                        else if ( iterator_time == dictionary.size() ) {
                            word new_word(val_1);
                            new_word.occur(line_num);
                            
                            dictionary.push_back(new_word);
                            break;
                        }
                        
                    }
                }//else
            }//while trim > val_1
        }//if ! input.empty()
    }//while input.good()
    
    //sort the list alphabetically
    dictionary.sort(cmp_by_name);
    
    for (list<word>::iterator it = dictionary.begin(); it != dictionary.end(); ++it) {
        output << *it << ": ";
        int *arr = it -> getRow();
        int row_arr_size = it -> get_row_size();
        int same_line_count = 1;
        
        for (int i = 0; i < row_arr_size; ++i) {
            //count for duplicate line numbers
            //      in order to have like: about: 61(2)
            //arr[i] has next && arr[i+1] == arr[i]
            while ( ( i + 1 < row_arr_size ) && ( arr[i + 1] == arr[i] ) ) {
                ++same_line_count;
                ++i;
            }
            //either arr[i] does not have next or
            //      arr[i+1] != arr[i]
            if (same_line_count != 1) {
                output << arr[i] << "(" << same_line_count;
                if (i != row_arr_size - 1) {
                    output << "), ";
                }else{
                    output << ")";
                }
                same_line_count = 1;
            }//if
            //if the next one is different, just print out.
            else if (i + 1 <= row_arr_size && arr[i + 1] != arr[i]){
                output << arr[i];
                if (i != row_arr_size - 1) {
                    output << ", ";
                }
            }
        }//for int i = 0 i < row arr size
        output << endl;
    }//for list<word>::iterator
    
    
    input.close();
    output.close();
    return 0;
}
