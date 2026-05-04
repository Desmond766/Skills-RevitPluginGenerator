---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCData.AsInstance
source: html/be7f2b49-3e31-c396-9df1-a46bd0bcf4a6.htm
---
# Autodesk.Revit.DB.IFC.IFCData.AsInstance Method

Gets storage value as IFCAnyHandle when its PrimitiveType is instance.

## Syntax (C#)
```csharp
public IFCAnyHandle AsInstance()
```

## Returns
The IFCAnyHandle.

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - The primitive type is not instance.

