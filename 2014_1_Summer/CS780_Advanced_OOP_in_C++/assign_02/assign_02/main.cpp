//
//  main.cpp
//  assign_02
//
//  Created by Youchen Ren on 6/5/14.
/*
    ( ( n & ( n - 1 ) ) == 0)
    this returns true if n is either zero or a power of 2.
    
    This is TRUE.
    Proof:
          "&" is called "Bitwise" AND operator in C++ reference.
            it returns the "bit value" by evaluation of the AND logic.
                ex: 4 -> 100 in binary;
                    3 -> 011 in binary;
 
                    4 & 3 =
 
                        100
                    &   011
                ================
                        000
        
                since the logic AND rule is that
                it takes two binary representations of equal length 
                    and performs the logical AND operation on each pair 
                    of corresponding bits. 
                    The result in each position is 1 if the first bit is 1 
                    and the second bit is 1; otherwise, the result is 0.
 
            since in current computer architecture is using 2's complement, and
            size of type "int" is 4 byte(32 bits).
 
            so in binary -1 = 111...1111 (32 one's)
                          0 = 000...0000 (32 zero's)
                          2 = 000...0010 (32 digits)
                          4 = 000...0100 (32 digits)
                          8 = 000...1000 (32 digits)
                          ...
            it's obvious that in binary number "-1" is the complement of number "0".
            after the AND logic to these two numbers, the result will be like:
                          000...0000 which is equal to 0 in Decimal.
 
            If n is the power of 2 instead of 0, let's see what happends.
            as stated above:
                          2 = 000...0010 (32 digits)
                          1 = 000...0001 (32 digits)
 
                          4 = 000...0100 (32 digits)
                          3 = 000...0011 (32 digits)
 
                          8 = 000...1000 (32 digits)
                          7 = 000...0111 (32 digits)
                          ...
 
            therefore, we can see that every "n" and "n - 1" is bitwise "complementable".
            It means that every bit of "n" is a complement of every bit of "n - 1".
 
            Apparently, if we logic AND "n" with "n - 1", we will get 000...0000 which is 0
            in decimal.
            
            we can also prove this like this way:
            
            In binary, we represent the decimal number by the equation of
                2^32 * __ + 2^31 * __ + ... + 2^3 * __ + 2^2 * __ + 2^1 * __ + 2^0 * __
 
            if we fill the blank above by 31 "zero's" and 1 "one" regardless their position.
            we will get a number which is power of 2 in decimal.
            
            Say, we will put this "one" in position p (from left to right, the sequence of blank
            is position 1, 2, 3, 4...), and the rest we put all "zero" there, then we have a
            decimal number X which is power of 2.
            
            if we express "X - 1" in binary, we will easily figure out that we need to change the
            original "one" there to "zero" and write all "one" to the bits afterwards.
 
            It's obviously that "X - 1" is the complement of "X".
            Therefore, If we logic AND on "X" and "X - 1", we will easily get 000...0000.
 
            
 
            Further thinking:
            By study the 2's complemt a little bit. I realized that I could make a statement
            like the question:
 
            I have a expression:
              (  n & ( -n - 1 ) == 0  )
            this returns true if n is either zero or a power of 2.
            
            actually, this is considering the n and -(n+1).
            it is easy to see that the following numbers are bitwise "complementable".
                    2 & -3
                    4 & -5
                    ...
            
            below is a demo for this proof.
 */

#include <iostream>
#include <cmath>
using namespace std;

int main(int argc, const char * argv[])
{
    int n;
    for (int i = 0; i <= 31; i++) {
        
        n = pow(2, i);
        
        if ( ( n & (n-1)) != 0 )
            cerr << "mistake!\n";
        
        if ( (n & (-n - 1)) != 0)
            cerr << "mistake!\n";
        
    }
    //nothing printed.
    
    return 0;
}

