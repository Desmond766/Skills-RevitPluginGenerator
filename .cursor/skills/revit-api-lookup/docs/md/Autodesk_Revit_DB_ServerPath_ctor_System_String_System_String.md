---
kind: method
id: M:Autodesk.Revit.DB.ServerPath.#ctor(System.String,System.String)
source: html/3d9c4f6b-8e64-33c1-c0e4-2a1157b823d9.htm
---
# Autodesk.Revit.DB.ServerPath.#ctor Method

Constructs a ServerPath

## Syntax (C#)
```csharp
public ServerPath(
	string centralServerLocation,
	string path
)
```

## Parameters
- **centralServerLocation** (`System.String`) - The name of the central Revit server
- **path** (`System.String`) - The path of the model. This path must be relative.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

