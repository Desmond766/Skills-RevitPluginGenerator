---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.Entity.RecognizedField(Autodesk.Revit.DB.ExtensibleStorage.Field)
source: html/4ba0ba57-2a35-a5e7-ec21-57af6808da73.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.Entity.RecognizedField Method

Checks whether a Field belongs to the same Schema as this Entity.

## Syntax (C#)
```csharp
public bool RecognizedField(
	Field field
)
```

## Parameters
- **field** (`Autodesk.Revit.DB.ExtensibleStorage.Field`) - The Field to check.

## Returns
True if the Field belongs to the same Schema as this Entity.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

