---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceReference.GetResourceVersionStatus
source: html/deda452b-a0de-4431-450e-f2299c81d6d7.htm
---
# Autodesk.Revit.DB.ExternalResourceReference.GetResourceVersionStatus Method

Checks whether this ExternalResourceReference corresponds to the current version of the resource.

## Syntax (C#)
```csharp
public ResourceVersionStatus GetResourceVersionStatus()
```

## Returns
An enum indicating whether this reference represents the most recent version
 of the resource.

## Remarks
This method should only be called if the ExternalResourceServer that provides the resource
 is present.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The server referenced by the ExternalResourceReference does not exist or
 does not implement IExternalResourceServer.

