---
kind: method
id: M:Autodesk.Revit.DB.PointCloudType.Create(Autodesk.Revit.DB.Document,System.String,System.String)
zh: 创建、新建、生成、建立、新增
source: html/2a1fb419-d46e-1acb-90ee-a668ae3ff3eb.htm
---
# Autodesk.Revit.DB.PointCloudType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new point cloud type for a given point cloud engine.

## Syntax (C#)
```csharp
public static PointCloudType Create(
	Document document,
	string engineIdentifier,
	string typeIdentifier
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the point cloud.
- **engineIdentifier** (`System.String`) - The string identifying the engine to be invoked.
 It should be the file extension or engine identifier registered by the third party.
- **typeIdentifier** (`System.String`) - The file name or the identification string for a non-file based engine.

## Returns
The newly created PointCloudType object to be used to create instances of
 this point cloud.

## Remarks
A list of supported engine identifiers and whether they are file-based or not can be
 obtained from PointCloudEngineRegistry. The method GetSupportedEngines() returns a list
 of the identifiers registered for engines.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The engine identifier was not found in the Revit session.
 -or-
 document is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileNotFoundException** - The external file could not be found or loaded.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Unable to create a point cloud from the third party engine.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

