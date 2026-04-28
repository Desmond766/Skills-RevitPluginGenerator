---
kind: property
id: P:Autodesk.Revit.DB.DataConversionMonitorScope.IsValidObject
source: html/738806eb-7e29-fa8d-e9af-8c484a67575b.htm
---
# Autodesk.Revit.DB.DataConversionMonitorScope.IsValidObject Property

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

