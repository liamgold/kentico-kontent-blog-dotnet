# Blog website using Kentico Cloud

This is a basic implementation of a blog website written in C# .NET MVC using Kentico Cloud as the headless CMS.

The main purpose for this project is to provide a base for building other personal Kentico Cloud websites in future.

The project currently requires an external **AppSettings.config** file.  The config file should have similar content to the below XML, with **YOUR_PROJECT_ID** replaced with the correct Kentico Cloud project ID.

```xml
    <?xml version="1.0" encoding="utf-8"?>
    <appSettings>
        <add key="ProjectId" value="YOUR_PROJECT_ID" />
    </appSettings>
```
