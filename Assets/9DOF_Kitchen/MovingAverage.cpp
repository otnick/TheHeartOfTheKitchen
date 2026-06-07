#include "MovingAverage.h"

MovingAverage::MovingAverage(int size){
  windowSize = size;
  readings = new int[windowSize];
  index = 0;
  total = 0;
  for (int i = 0; i < windowSize; i++) readings[i] = 0;
}

void MovingAverage::update(int value){
  total -= readings[index]; // subtract the previous value of this index
  readings[index] = value; // replace the value in the list
  total += value; // add the new value to the total
  index = (index + 1) % windowSize; //advance one index. if it equals to windowsize we go back to index 0
}

float MovingAverage::getAverage(){
  return total/windowSize;
}