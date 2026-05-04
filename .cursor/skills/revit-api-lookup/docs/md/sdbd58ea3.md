---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.Pipe.SetSystemType(Autodesk.Revit.DB.ElementId)
zh: 管道、水管、管线
source: html/dd13a0f2-4820-a6f2-3b8e-56c8d980060f.htm
---
# Autodesk.Revit.DB.Plumbing.Pipe.SetSystemType Method

**中文**: 管道、水管、管线

Updates the associated system type for the pipe.

## Syntax (C#)
```csharp
public void SetSystemType(
	ElementId systemTypeId
)
```

## Parameters
- **systemTypeId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the piping system type.

## Remarks
If the pipe previously did not have a system associated to it, this will create a new system.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The systemTypeId is not valid piping system type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

