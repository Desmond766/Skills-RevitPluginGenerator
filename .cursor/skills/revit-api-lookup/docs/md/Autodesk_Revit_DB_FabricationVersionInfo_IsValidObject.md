---
kind: property
id: P:Autodesk.Revit.DB.FabricationVersionInfo.IsValidObject
source: html/b708b2a9-ccda-b218-df51-0cc666a674e8.htm
---
# Autodesk.Revit.DB.FabricationVersionInfo.IsValidObject Property

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

