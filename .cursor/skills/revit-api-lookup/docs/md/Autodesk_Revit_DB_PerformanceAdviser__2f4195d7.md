---
kind: type
id: T:Autodesk.Revit.DB.PerformanceAdviser
source: html/f9b0b017-f98f-79a3-ce7b-b1c867bb22f2.htm
---
# Autodesk.Revit.DB.PerformanceAdviser

The tool to report performance problems in a given document.

## Syntax (C#)
```csharp
public class PerformanceAdviser : IDisposable
```

## Remarks
Class is an application-wide singleton that performs a dual role: it is a repository of rules to run
 in order to detect potential performance problems as well as an access point to execute checks.

