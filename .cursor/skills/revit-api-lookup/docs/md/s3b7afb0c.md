---
kind: property
id: P:Autodesk.Revit.DB.RevitLinkType.PathType
source: html/c0517436-dea9-9728-1876-de384b2fbc96.htm
---
# Autodesk.Revit.DB.RevitLinkType.PathType Property

The type of path the link uses.

## Syntax (C#)
```csharp
public PathType PathType { get; set; }
```

## Remarks
You cannot change the PathType to or from PathType.Server. The
 path type will change automatically if you call RevitLinkType.LoadFrom
 with a Revit Server path. Links from external resource servers are considered to have no path
 type. Attempts to access this property for an external server link
 will result in an exception.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The PathType of the Revit link cannot be determined (or set), because it was
 not loaded from a local disk drive or from Revit Server.
 -or-
 When setting this property: The PathType for the link is not valid. PathType.Content is never
 valid for a Revit link. To change the type to or from PathType.Server,
 use RevitLinkType.LoadFrom and pick a server or file path.

