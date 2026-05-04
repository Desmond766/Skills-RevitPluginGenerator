---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCAnyHandle.IsTypeOf(System.String)
source: html/5e94f8e8-0ec3-ea5b-e46f-f16696fab7e3.htm
---
# Autodesk.Revit.DB.IFC.IFCAnyHandle.IsTypeOf Method

Determines whether the instance is an instance of exactly the specified instance type.

## Syntax (C#)
```csharp
public bool IsTypeOf(
	string typeName
)
```

## Parameters
- **typeName** (`System.String`) - The instance type name.

## Returns
True if the instance is an instance of the specified instance type, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

