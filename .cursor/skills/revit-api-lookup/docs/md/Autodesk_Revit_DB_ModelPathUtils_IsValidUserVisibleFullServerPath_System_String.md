---
kind: method
id: M:Autodesk.Revit.DB.ModelPathUtils.IsValidUserVisibleFullServerPath(System.String)
source: html/9e5b3ef7-a8f0-bf55-db79-63ff079b869b.htm
---
# Autodesk.Revit.DB.ModelPathUtils.IsValidUserVisibleFullServerPath Method

Determines whether the given string represents a valid
 server path.

## Syntax (C#)
```csharp
public static bool IsValidUserVisibleFullServerPath(
	string strPath
)
```

## Parameters
- **strPath** (`System.String`) - The path, in string form

## Returns
True if the given path is a valid server path, false otherwise.

## Remarks
ServerPaths must refer to Revit models. ServerPaths are relative to the central server location, and
 are of the form "RSN://{HostNodeName}/{model_path}". The {model_path}
 portion is a relative path to a Revit model. For example: RSN://EXS/hospital.rvt RSN://EXS.autodesk.com/Old Files/hotel2.rvt RSN://EXS.autodesk.com/Old Files/Last Week/Tuesday\hotel2.rvt 
 are all valid server paths.
 //EXS/Old Files/.rvt EXS/hospital 
 are not valid server paths.
 If this function returns false, it does not necessarily mean
 the given path is a file path. It may be a malformed string.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

