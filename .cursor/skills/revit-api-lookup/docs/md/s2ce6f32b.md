---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCAnyHandle.IsSubTypeOf(System.String)
source: html/a7f06a9b-4c83-c6ff-ed7b-6625f41985d4.htm
---
# Autodesk.Revit.DB.IFC.IFCAnyHandle.IsSubTypeOf Method

Determines whether the instance is an instance of the specified instance type or a subtype of this instance type.

## Syntax (C#)
```csharp
public bool IsSubTypeOf(
	string typeName
)
```

## Parameters
- **typeName** (`System.String`) - The instance type name.

## Returns
True if the instance is an instance of the specified instance type or its subtype, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

