//
//  main.cpp
//  assign_07
//
//  Created by Youchen Ren on 6/22/14.
/*
 I did a lot trials for getting rid of the circular permutation.
 But still I cannot figure out how to eliminate the circular permutation.
 This project cost too much time.
 If you could be lenient to my effort, then Thanks so much.
 
 And Thanks for grading my project!
 
 
 */

#include <iostream>
using namespace std;

void printArr(int arr[], int length){
    for (int i = 0; i < length; i++) {
        
        if (arr[i] > 0) {
            cout << "+";
        }
        cout << arr[i] << " ";
    }
    cout << endl;
}

bool seatOK(int arr[], int length){
    
    bool condition1 = true, condition2 = true;
    
    //+ - + -: 1 male and 1 female;
    for (int i = 0; i < length; i++) {
        if (i == length - 1) {
            if ( ((double)arr[0] / (double)arr[length - 1]) > 0) {
                condition1 = false;
            }
        }else{
            if ( ((double)arr[i+1] / (double)arr[i]) > 0) condition1 = false;
        }
    }
    
    //No one may be seated next to their own teammate.
    //  ex: -1 +1 is not allowed.
    for (int i = 0; i < length; i++) {
        if (i == length - 1) {
            if ( arr[0] / arr[length - 1] == -1) {
                condition2 = false;
            }
        }else{
            if (arr[i+1] / arr[i] == -1) condition2 = false;
        }
    }
    
    return (condition1 && condition2);
}

int factorial(int n){
    if(n <= 1) return 1;
    return n * factorial(n - 1);
}

int main(int argc, const char * argv[])
{
    int n = 2, cases = 0;
    int mapArrR = factorial(n);
    int mapArrC = n*2;
    //declare an 2d array to store the distinct circular array.
    int mapArr[ mapArrR ][ mapArrC ];
    
    while (n != 9) {
        
        //initilize all the cell tobe -1.1
        
        for (int i = 0; i < mapArrR; i++) {
            for (int j = 0; j < mapArrC; j++) {
                mapArr[i][j] = -1;
            }
        }
        //this is the index for the big map array.
//        int x = 0;
        
        cout << "case " << n << ": ";
        int arr[ mapArrC ];
        
        //generate the people.
        //  such as 1 -1 2 -2 ...
        for (int i = 0; i < n*2; i += 2) {
            arr[i] = (i + 2) / 2;
            arr[i + 1] = (-1) * arr[i];
        }
        
        
        
        
        sort (arr,arr+(n*2));
        
        do {
            if (seatOK(arr, n*2) ) {
                //if mapArr does not have this array, then store it.
                //Jun23
                //1. map iterator vector
                //2. 2d array
//                bool noSuchPermutation = true;
//                
//                
////                for (int i = 0; mapArr[i][0] != -1; i++) {
////                    for (int j = 0; j < n*2; j++) {
//                if (mapArr[0][0] != -1 ) {
//                    
//                        int k = 0;
//                        //if 1st is not match 1st.
//                        //    find the index until they are match.
//                        while ( arr[k] != mapArr[x][0] ) {
//                            //if no matches, compare the next row of MapArr
//                            if (k == n*2 - 1) {
//                                ++x;
//                                if ( mapArr[x][0] == -1 ) {
//                                    //add arr to the mapArr:
//                                    for (int z = 0; z < n*2; z++) {
//                                        mapArr[x][z] = arr[z];
//                                    }
//                                    x++;
//                                }else{
//                                    k = 0;
//                                }
//                            }//if
//                            k++;
//                        }
//                
//                        //if 1st IS match 1st.
//                        //     then compare the rest.
//                        if (k != n*2 - 1) {
//                            //find a match!
//                            if ( arr[k] == mapArr[i][j] ) {
//                                for (int l = k; l <= (l + n*2 - 1); l++) {
//                                    if ( arr[l % (n*2)] != mapArr[i][] ) {
//                                             break;
//                                             //find the next row of mapArr.
//                                    }
//                                }
//                            }
//                        }//if k != n*2 - 1;
//                        
//                        
////                    }
//                
//                    
//                    
//                    
//                    
////                }
//                //if cannot find as last, noSuch.. = true;
//                
//                }else{
//                    
//                    if ( noSuchPermutation ) {
//                        for (int z = 0; z < n*2; z++) {
//                            mapArr[x][z] = arr[z];
//                        }
//                        x++;
//                    }
//                }
//                //store this ok array into mapArr.
//                for (int i = 0; i < n*2; i++) {
//                    cout << mapArr[x][i] << " ";
//                }
//                
//                
//                
//                for (int i = 0; i < (n*2); i++) {
//                    mapArr[x][i] = arr[i];
//                }
//                x++;

                
                cases++;
                
            }
        } while ( next_permutation(arr,arr+(n*2)) );
        
        //shrink the mapArr by comparison the circular permutation.
//        for (int i = 0; i < mapArrR; ++i) {
//            for (int j = 0; j < mapArrR; ++j) {
//                if (i == j) {
//                    continue;
//                }else{
//                    int base = 0, compare = 0;
//                    while (mapArr[j][compare] != mapArr[i][base]) {
////                        if (compare == n*2 - 1) {
////                            //these two are not match.
////
////                        }
//                        
//                        
//                        ++compare;
//                    }//while
//                    while ( (mapArr[j][compare % (n*2) ] == mapArr[i][base] ) && ( base <= ( n*2 -1 ) )) {
//                        if (base == n*2 - 1) {
//                            //delete compare
//                            for (int d = 0; d < n*2; ++d) {
//                                mapArr[j][d] = -100;
//                            }
//                        }
//                        
//                        
//                        ++compare;
//                        ++base;
//                    }//while
//                }//else
//                
//            }
//        }//for shrink
//        
//        
//        //count for valid rows.
//        for (int i = 0; i < mapArrR; ++i) {
//            if (mapArr[i][0] != -100) {
//                cases++;
//            }
//        }
//        
//        
//        
//        
        cout << cases << endl;
        
        
        
        
        
        
        sort (arr,arr+(n*2));
        
        do {
            if (seatOK(arr, n*2) ) {
                printArr(arr, n*2);
            }
        } while ( next_permutation(arr,arr+(n*2)) );
       
        ++n;
    }//while n != 9
    
    return 0;
}




