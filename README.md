# Blog website using Kentico Cloud

This is a basic implementation of a blog website written in C# .NET MVC using Kentico Cloud as the headless CMS.

The main purpose for this project is to provide a base for building other personal Kentico Cloud websites in future.

The project currently requires an external **AppSettings.config** with the following contents:

 ```xml
    <?xml version="1.0" encoding="utf-8"?>
    <appSettings>
        ...
        <add key="ProjectId" value="YOUR_PROJECT_ID" />
        ...
    </appSettings>
    ```
