---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceReference.CreateLocalResource(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ExternalResourceType,Autodesk.Revit.DB.ModelPath,Autodesk.Revit.DB.PathType)
source: html/457745f0-5346-77ed-444b-554295ebb14b.htm
---
# Autodesk.Revit.DB.ExternalResourceReference.CreateLocalResource Method

Creates an ExternalResourceReference representing a local file managed
 by Revit's built-in server.

## Syntax (C#)
```csharp
public static ExternalResourceReference CreateLocalResource(
	Document doc,
	ExternalResourceType resourceType,
	ModelPath path,
	PathType pathType
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document containing the reference. If the PathType is relative,
 the path will be made relative to the location of this Document. (If
 this Document belongs to a workshared model,
 the reference will be relative to the central model.)
- **resourceType** (`Autodesk.Revit.DB.ExternalResourceType`) - The type of the external resource.
- **path** (`Autodesk.Revit.DB.ModelPath`) - A path to the external file. This path must be absolute. If the PathType is
 relative, then Revit will relativize the path according to the location
 of the given Document.
- **pathType** (`Autodesk.Revit.DB.PathType`) - An enum indicating the type of path which the ExternalResourceReference should use.
 The PathType must be PathType.Server if the reference is to a Revit model on
 Revit Server. The PathType must be PathType.Absolute if the reference is local
 but the host model or host's central model are on Revit Server.

## Returns
The newly-created ExternalResourceReference.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The PathType.Enum value is not valid for this resource type or Document location.
 PathType.Content is not valid for Revit links. The PathType must be PathType.Server
 if the resource is on Revit Server and is only valid for Revit links. The PathType
 must be PathType.Absolute if the host document or the host document's central model
 are on Revit Server.
 -or-
 The given path path is a cloud path which is not supported in this method.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The model is not allowed to access.

