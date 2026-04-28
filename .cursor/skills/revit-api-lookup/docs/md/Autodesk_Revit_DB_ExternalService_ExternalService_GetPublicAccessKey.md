---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.ExternalService.GetPublicAccessKey
source: html/d40f5730-6deb-2b5c-1d42-b5abfbc2a625.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalService.GetPublicAccessKey Method

Access key to use to execute a service.

## Syntax (C#)
```csharp
public Guid GetPublicAccessKey()
```

## Returns
GUID representing the access key.

## Remarks
The service must be declared as public in order for callers be
 able to invoke this method. Services that are not public can be
 executed only by their owners (the ones who registered it). Most services are not public and may only be executed by their
 respective owners. To see whether a service was declared as public,
 call the GetOptions method and check the IsPublic property.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The service is not public, thus the access key cannot be obtained.

