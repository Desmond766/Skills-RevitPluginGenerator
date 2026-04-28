---
kind: method
id: M:Autodesk.Revit.DB.Material.IsNameUnique(Autodesk.Revit.DB.Document,System.String)
zh: 材质、材料
source: html/7c36f870-2492-fa94-0720-0875df529c42.htm
---
# Autodesk.Revit.DB.Material.IsNameUnique Method

**中文**: 材质、材料

Validates whether the material name is unique in document.

## Syntax (C#)
```csharp
public static bool IsNameUnique(
	Document aDocument,
	string name
)
```

## Parameters
- **aDocument** (`Autodesk.Revit.DB.Document`) - The document in which the name is being tested for uniqueness.
- **name** (`System.String`) - The name tested for uniqueness.

## Returns
Returns true if the name is unique, and false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

