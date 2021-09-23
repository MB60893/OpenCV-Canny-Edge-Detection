# OpenCV Canny Edge Detection
A simple Canny-Edge Detection implementation in C# using Open Computer Vision libraries. It takes video from a webcam, performs a standard canny-edge detection and then applies a bitwise AND on the white lines produced to turn them transparent, allowing a rainbow background to shine through.

To run the code, simply open the solution in Visual Studio, wait for the NuGet Packages for OpenCV to be installed, then run the application in debug mode.

NOTE: The default camera for the system will be used. If you wish to change this, set the VideoCapture() parameter to a positive integer representing the next webcam you have attached to your computer.
