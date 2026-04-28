---
kind: property
id: P:Autodesk.Revit.DB.Macros.MacroModule.IsValidObject
source: html/3ae28cc1-ba19-6e32-c326-ab32d06151ca.htm
---
# Autodesk.Revit.DB.Macros.MacroModule.IsValidObject Property

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

