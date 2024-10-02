Retry Pattern Implementation in C#
This project demonstrates two approaches to implementing the Retry Pattern in C#:
A simple custom implementation without using any external libraries
An implementation using the Polly library

Project Structure
The repository contains two main C# files:
SimpleRetryPattern.cs: Custom implementation of the Retry Pattern
RetryUsingPolly.cs: Implementation using the Polly library

Simple Retry Pattern Implementation
The SimpleRetryPattern.cs file contains a custom implementation of the Retry Pattern without relying on external libraries.

Retry Pattern Using Polly
The RetryUsingPolly.cs file demonstrates how to implement the Retry Pattern using the Polly library. It showcases:
Installation of the Polly NuGet package
Creation of a retry policy with Polly
Configuration of retry count, delay, and exception handling

Getting Started
Clone the repository
Open the solution in Visual Studio or your preferred C# IDE
Ensure you have the Polly NuGet package installed for the Polly implementation
Run the project to see the retry pattern in action
