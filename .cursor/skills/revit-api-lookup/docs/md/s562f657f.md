---
kind: type
id: T:Autodesk.Revit.DB.IDataConversionMonitor
source: html/7afa9e0c-a245-f215-77fa-9201f25dc6ad.htm
---
# Autodesk.Revit.DB.IDataConversionMonitor

A base class for an application-specific logger. It should be used to track errors during conversion and/or , track conversion progress, cancel a conversion process if necessary.
 Implementing a logger class is optional, but highly recommended for all but most basic data converters.
 The base class is UI- and language-independent. It is up to the using app to implement UI. Language-specifc data may be used to communicate information to application users.
 English should be used to communicate data of interest to Revit development.

## Syntax (C#)
```csharp
public interface IDataConversionMonitor
```

