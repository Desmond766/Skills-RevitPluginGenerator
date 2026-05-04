---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceReference.IsValidReference(Autodesk.Revit.DB.ExternalResourceType)
source: html/7df2f669-5190-1777-f5d3-6da110240711.htm
---
# Autodesk.Revit.DB.ExternalResourceReference.IsValidReference Method

Checks whether the reference is in a valid format.

## Syntax (C#)
```csharp
public bool IsValidReference(
	ExternalResourceType resourceType
)
```

## Parameters
- **resourceType** (`Autodesk.Revit.DB.ExternalResourceType`) - The type of resource which the ExternalResourceReference should
 correspond to.

## Returns
True if this is a valid ExternalResourceReference. False otherwise.

## Remarks
This function checks:
 The server id corresponds to a valid server which
 implements IExternalResourceServer. The server supports the given ExternalResourceType. The reference information is well-formed. 
 This function does not check whether the resource exists
 on the server.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

