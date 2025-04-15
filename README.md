
# Week 8 Day 3 Task - ASP.NET Core MVC

## Overview
This project demonstrates several features of ASP.NET Core MVC including:
- Fetching data from an external API
- Using Redis and In-Memory caching
- Dynamic UI updates using JavaScript and Fetch API
- Lazy loading images using IntersectionObserver

## Features

### 1. Redis & In-Memory Caching
- Controllers: `RedisController`, `InMemoryController`
- Purpose: Demonstrates how caching works in .NET Core

### 2. Fetching External API Users
- API Controller: `UsersApiController`
- Endpoint: `/api/UsersApi/GetUsers`
- Uses `HttpClient` to fetch users from https://jsonplaceholder.typicode.com/users

### 3. Dynamic JavaScript Fetch UI
- File: `wwwroot/fetch-users.html`
- Fetches users via JavaScript and renders them dynamically
- Uses `loading="lazy"` for avatars

### 4. Razor-Based Lazy Loading Gallery
- Controller: `GalleryController`
- View: `Views/Gallery/Index.cshtml`
- Uses IntersectionObserver to lazy load user images
- Displays user avatars

## How to Run
1. Run the project using Visual Studio or `dotnet run`
2. Navigate to the navbar to explore Redis, In-Memory, Gallery, and JavaScript Fetch page