---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCAggregate.AddValueOfType(System.String)
source: html/50bd722c-6ab0-888c-7059-7b999d6b9e28.htm
---
# Autodesk.Revit.DB.IFC.IFCAggregate.AddValueOfType Method

Adds an ifc object with primitive type of aggregate's item type to the aggregate.

## Syntax (C#)
```csharp
public void AddValueOfType(
	string typeName
)
```

## Parameters
- **typeName** (`System.String`) - The type name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The aggregate is not valid.

