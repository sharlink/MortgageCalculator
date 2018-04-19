# Mortgage Calculator
MortgageCalculator

This document describes how to configure the Mortgage Calculation application and this include following projects.

•	MortgageCalculator.Api

•	MortgageCalculator.Api.UnitTests

•	MortgageCalculator.Dto

•	MortgageCalculator.Web

•	MortgageData

Web application calling api for retrieving data and api base url configured in Scripts/Common/common.js.
This is a SPA and made all calls from client side.

In Web API I have used following open source libraries.

1.	ASP.NET Web API CacheOutput

    A small library bringing caching options, similar to MVC's "OutputCacheAttribute", to Web API actions.
    CacheOutput will take care of server side caching and set the appropriate client side (response) headers for you.

2.	Unity Container

    The Unity Container (Unity) is a lightweight, extensible dependency injection container. 
    It facilitates building loosely coupled applications.
    
3.	NLog

    NLog is a logging platform for .NET with rich log routing and management capabilities.
    NLog supports traditional logging, structured logging and the combination of both
    
4.	Swashbuckle - Swagger for WebApi

    Swagger is a specification for documenting REST API. It specifies the format (URL, method, and representation) to describe REST web     services.

5.	AutoMapper

    A convention-based object-object mapper. AutoMapper uses a fluent configuration API to define an object-object mapping strategy. AutoMapper uses a convention-based matching algorithm to match up source to destination values. Currently, AutoMapper is designed for model projection scenarios to flatten complex object models to DTOs and other simple objects, whose design is better suited for serialization, communication, messaging, or simply an anti-corruption layer between the domain and application layer.

I have also included unit testing using Moq framework.

Happy coding……

Thanks!
Sharlin


