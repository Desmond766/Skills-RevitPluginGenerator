---
kind: method
id: M:Autodesk.Revit.DB.Visual.AssetProperty.IsEditable
source: html/8e7fa788-9842-883d-16f1-73b5a0802d61.htm
---
# Autodesk.Revit.DB.Visual.AssetProperty.IsEditable Method

Check if property can be edited.

## Syntax (C#)
```csharp
public bool IsEditable()
```

## Returns
True if property is editable.

## Remarks
Properties can be edited only if there is an active Edit Scope and if the property is allowed to be changed.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The asset property is not editable. Asset can be edited only in an edit scope.

