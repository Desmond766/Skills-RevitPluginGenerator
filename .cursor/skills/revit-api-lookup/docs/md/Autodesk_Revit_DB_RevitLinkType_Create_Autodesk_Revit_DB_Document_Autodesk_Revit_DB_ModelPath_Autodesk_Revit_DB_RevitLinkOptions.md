---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ModelPath,Autodesk.Revit.DB.RevitLinkOptions)
zh: 创建、新建、生成、建立、新增
source: html/0dd0e8bd-5217-9a94-19bb-58dcb840e517.htm
---
# Autodesk.Revit.DB.RevitLinkType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new Revit link type and loads the linked document.

## Syntax (C#)
```csharp
public static LinkLoadResult Create(
	Document document,
	ModelPath path,
	RevitLinkOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the Revit link.
- **path** (`Autodesk.Revit.DB.ModelPath`) - The path of the link to load. This may be a path of local disk, Revit Server or Cloud.
 This must be a full path.
- **options** (`Autodesk.Revit.DB.RevitLinkOptions`) - An options class for loading Revit links.

## Returns
An object containing the results of creating and loading
 the Revit link type. It contains the ElementId of the new link.

## Remarks
This function regenerates the input document.
While the options argument allows specification of a path type, the
 input path argument must be a full path. Relative vs. absolute determines
 how Revit will store the path, but it needs a complete path to find
 the linked document initially.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 Server paths cannot be relative.
 -or-
 document already contains a linked model at path path.
 -or-
 The path to be linked in is empty.
 -or-
 The input path "path" does not represent a Revit model.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileAccessException** - The model cannot be accessed due to lack of access privileges.
- **Autodesk.Revit.Exceptions.FileNotFoundException** - The path to be linked in doesn't exist.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The model is not allowed to access.
 -or-
 Revit cannot customize worksets for this model.
 -or-
 Revit cannot link a cloud model to non-cloud model.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - Could be for any of the reasons that failed on service side.
- **Autodesk.Revit.Exceptions.RevitServerUnauthenticatedUserException** - User is not signed in with Autodesk id.
- **Autodesk.Revit.Exceptions.RevitServerUnauthorizedException** - User is not authorized to access the specified cloud model.

