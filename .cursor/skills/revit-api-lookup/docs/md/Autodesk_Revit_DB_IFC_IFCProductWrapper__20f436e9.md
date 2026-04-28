---
kind: type
id: T:Autodesk.Revit.DB.IFC.IFCProductWrapper
source: html/368d2c50-1258-32a9-00ed-cc41059a6694.htm
---
# Autodesk.Revit.DB.IFC.IFCProductWrapper

This class is used to ensure that elements and objects are associated with the current IfcProduct.

## Syntax (C#)
```csharp
public class IFCProductWrapper : IDisposable
```

## Remarks
Each instance makes sure that any elements and products created during its lifetime are properly associated to their parent level (or other containing object).
 To ensure that the lifetime of the object is correctly managed, you should declare an instance of this class as a part of a 'using' statement in C# or
 similar construct in other lanuguages.

