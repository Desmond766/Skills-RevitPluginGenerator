---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipeScheduleType.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/1dee62b6-2042-7144-1c5d-b1e3ad26cd25.htm
---
# Autodesk.Revit.DB.Plumbing.PipeScheduleType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new pipe schedule type with the given name.

## Syntax (C#)
```csharp
public static PipeScheduleType Create(
	Document doc,
	string name
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document
- **name** (`System.String`) - The name of requested schedule type.

## Returns
Returns the newly created schedule type.

## Remarks
If the name is already taken by an existing schedule type, an InvalidOperationException will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The name is already taken by an existing pipe schedule type.

