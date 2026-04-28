---
kind: method
id: M:Autodesk.Revit.DB.Document.MakeTransientElements(Autodesk.Revit.DB.ITransientElementMaker)
zh: 文档、文件
source: html/0decdddc-ae4a-d46d-d141-9d37e7973e05.htm
---
# Autodesk.Revit.DB.Document.MakeTransientElements Method

**中文**: 文档、文件

This method encapsulates the process of creating transient elements in the document.

## Syntax (C#)
```csharp
public void MakeTransientElements(
	ITransientElementMaker maker
)
```

## Parameters
- **maker** (`Autodesk.Revit.DB.ITransientElementMaker`) - An instance of a class that implements the ITransientElementMaker interface.
 The maker will be called to create element(s) which would become transient.

## Remarks
The method establishes a context within which transient elements will be created and then invokes the given maker object to create the elements. For more information refer to the IsTransient method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Document has an open editing transaction and is accepting changes.
 -or-
 This Document is read-only: It cannot be modified.

