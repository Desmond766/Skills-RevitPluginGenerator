---
kind: type
id: T:Autodesk.Revit.Exceptions.OutdatedDirectlyOpenedCentralException
source: html/d38fd86b-6281-788d-bf20-6b896da2fbbb.htm
---
# Autodesk.Revit.Exceptions.OutdatedDirectlyOpenedCentralException

The exception thrown when a central model is opened directly and its copy in the session is 
outdated. If the operation is supported for local files, first resave as local, and try again.

## Syntax (C#)
```csharp
[SerializableAttribute]
public class OutdatedDirectlyOpenedCentralException : CentralModelException
```

