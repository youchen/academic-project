//
//  main.cpp
//  assign_06
//
//  Created by Youchen Ren on 6/20/14.
//  Copyright (c) 2014 Youchen Ren. All rights reserved.
//
#include <vector>
#include <iostream>
#include <fstream>
#include <cstdlib>
#include <string>
using namespace std;
using std::vector;
using matrix = vector<vector<int>>;

class VNT{
private:
    int row, col;
    const int max = INT_MAX;
    
public:
//    VNT(int rows, int cols):
//    row(rows), col(cols){
////        return matrix(rows, vector<int>(cols, fill));
//        matrix(row, col);
//        
//        
//    }
    matrix construct(int rows, int cols, int fill = INT_MAX){
        return matrix(rows, vector<int>(cols, fill));
    }
};

int main (int argc, char* argv[]){
    if (argc < 3) { //first argument(argv[0]) is the program path
        cerr << "usage: " << argv[0] << " <input file> <dest file>" << endl;
        return 0;
	}
    
    string text;
    int row, col, size, number, *arr = nullptr, arrIndex = 0;
    //    bool okSort = false;
    fstream textfile;
    
    ifstream input(argv[1]);
	ofstream output(argv[2]);
    
    ifstream iFile(argv[1]);
    string line;
    
    textfile.open(argv[1]);
    
    while(!textfile.eof()){
        //get the 1st line of the input.
        getline(iFile, line);
        
        //read the 1st number = row of vnt;
        textfile >> text;
        row = atoi(text.c_str());
        
        //read the 2nd number = col of vnt;
        textfile >> text;
        col = atoi(text.c_str());
        
        //initializing vnt;
        vnt vnt1(row, col);
        output << "row & Col: " << row << " " << col << "END\n";
        output << "Original array: ";
        output << vnt1;
        
        
        //read the 3rd number = size;
        textfile >> text;
        size = atoi(text.c_str());
        
        
        //get the 2nd line of the input.
        getline(iFile, line);
        
        for (int i = 0; i < line.size(); i++) {
            //read the number and add into vnt;
            textfile >> text;
            number = atoi(text.c_str());
            
            //form an array
            arr = new int[size];
            arr[arrIndex++] = number;
            
            if ( (row * col) >= size) {
                vnt1.add(number);
                
                
            }
            
        }
        if ( (row * col) >= size) {
            vnt1.sort(arr, size);
            output << vnt1;
        }
    }
    
    input.close();
	output << flush;
	output.close();
    
	textfile.close();
    return 0;
}


