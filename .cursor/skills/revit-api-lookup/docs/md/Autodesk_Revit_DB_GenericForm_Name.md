---
kind: property
id: P:Autodesk.Revit.DB.GenericForm.Name
source: html/0cee40b9-1197-0662-6d82-35bad7aaebc4.htm
---
# Autodesk.Revit.DB.GenericForm.Name Property

Get and Set the Name property

## Syntax (C#)
```csharp
public override string Name { set; }
```

## Remarks
The method set is override to forbid the user to change the Name. When the user tries
to call the method set for GenericForm object, an InvalidOperationException will be thrown.

