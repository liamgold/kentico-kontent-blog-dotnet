# Blog website using Kentico Kontent

**Project has now been marked as archived.**

This is a basic implementation of a blog website written in C# .NET MVC using Kentico Kontent as the headless CMS.

The main purpose for this project is to provide a base for building other personal Kentico Kontent websites in future.

The project currently requires an external **AppSettings.config** file.  The config file should have similar content to the below XML, with **YOUR_PROJECT_ID** replaced with the correct Kentico Kontent project ID.

```xml
    <?xml version="1.0" encoding="utf-8"?>
    <appSettings>        
        <add key="webpages:Version" value="3.0.0.0" />
        <add key="webpages:Enabled" value="false" />
        <add key="ClientValidationEnabled" value="true" />
        <add key="UnobtrusiveJavaScriptEnabled" value="true" />
        <add key="ProjectId" value="YOUR_PROJECT_ID" />
    </appSettings>
```

Building front end files (initial setup used [generator-netconstruct](https://github.com/netconstruct/generator-netconstruct) yeoman template):
- open cmd
- run ```cd KontentBlog/SiteFiles/src/```
- run ```yarn```
- run ```yarn build```
