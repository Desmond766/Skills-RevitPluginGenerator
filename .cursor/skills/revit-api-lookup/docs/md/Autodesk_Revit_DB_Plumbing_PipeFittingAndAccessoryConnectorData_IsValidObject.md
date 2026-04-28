---
kind: property
id: P:Autodesk.Revit.DB.Plumbing.PipeFittingAndAccessoryConnectorData.IsValidObject
source: html/993495bc-b066-5c93-fb7c-c72e80156d12.htm
---
# Autodesk.Revit.DB.Plumbing.PipeFittingAndAccessoryConnectorData.IsValidObject Property

Specifies whether the .NET object represents a valid Revit entity.

## Syntax (C#)
```csharp
public bool IsValidObject { get; }
```

## Returns
True if the API object holds a valid Revit native object, false otherwise.

## Remarks
If the corresponding Revit native object is destroyed, or creation of the corresponding object is undone,
 a managed API object containing it is no longer valid. API methods cannot be called on invalidated wrapper objects.

