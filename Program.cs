using System;
using OpenCvSharp;

namespace CannyEdgeDetection {
	class Program {
		public static void Main(string[] args) {
			// Change the VideoCapture integer to specify a different camera. Default is zero.
			VideoCapture capture = new VideoCapture(0);
			using (Window window = new Window("Camera"))
			using (Mat frame = new Mat()) { // Frame image buffer
				while (true) {
					// Get a frame from the webcam.
					capture.Read(frame);
					// Some camera feeds are mirrored. It may be necessary to flip them here.
					Cv2.Flip(frame, frame, FlipMode.Y);
					// Apply a gaussian blur to the frame. This will help us identify edges more easily.
					Cv2.GaussianBlur(frame, frame, new Size(7, 7), 1.41);
					// Convert to grayscale.
					Cv2.CvtColor(frame, frame, ColorConversionCodes.BGR2GRAY);
					// Perform a Canny Edge Detection. Weightings below are determined through trial and error.
					Cv2.Canny(frame, frame, 25, 75);
					// Convert the frame back to BGR colourspace. This is needed for the Bitwise AND function.
					Cv2.CvtColor(frame, frame, ColorConversionCodes.GRAY2BGR);
					
					// Import our background for the mask to go on top of.
					Mat src1 = Cv2.ImRead("rainbow - Copy.jpg");
					// Resize the frame to the size of our mask.
					Cv2.Resize(frame, frame, new Size(640, 480));
					// Perform the bitwise AND on the background using the foreground as the mask
					Cv2.BitwiseAnd(src1, frame, frame);
					
					// Show the image.
					window.ShowImage(frame);

					// Delay 20 milliseconds between updates. If the letter Q is pressed, quit the application.
					if (Cv2.WaitKey(20) == 'q') {
						break;
					}
				}
			}
		}
	}
}

