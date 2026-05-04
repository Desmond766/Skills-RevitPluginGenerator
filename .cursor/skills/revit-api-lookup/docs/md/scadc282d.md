---
kind: property
id: P:Autodesk.Revit.DB.ExternalService.ExternalServiceOptions.IsSelfsynchronizing
source: html/de177fe1-b901-747e-d92d-26cd89e00471.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalServiceOptions.IsSelfsynchronizing Property

Indicates whether the service's record of used services (in a particular document)
 can independently wary between local clients and the corresponding central model.
 It is then up to the service's owner to assure proper local-central synchronization.

## Syntax (C#)
```csharp
public bool IsSelfsynchronizing { get; set; }
```

## Remarks
This property is ignored unless the service is also recordable. Declaring a service as self-synchronizing makes the service bypass standard
 worksharing checks during local-central synchronizations. What it means is that
 should there be any disparity found between the list of servers used in the local
 file and those used in the central file, they would get ignored; it would be
 assumed that the owner of the service takes other steps to ensure the local and
 the central data are in sync. Few services should need to set this property as True, for self-synchronizing
 services are very rare, practically limited only to those which operate on element
 level.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: A service that doens't support activation should not be self synchronizing.

