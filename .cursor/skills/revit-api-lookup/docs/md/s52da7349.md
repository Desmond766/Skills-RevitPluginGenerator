---
kind: method
id: M:Autodesk.Revit.DB.ModelPathUtils.ConvertCloudGUIDsToCloudPath(System.String,System.Guid,System.Guid)
source: html/aa710231-4cab-98ba-951f-00c72e06bb6e.htm
---
# Autodesk.Revit.DB.ModelPathUtils.ConvertCloudGUIDsToCloudPath Method

Converts a pair of cloud project and model GUIDs to a valid cloud path.

## Syntax (C#)
```csharp
public static ModelPath ConvertCloudGUIDsToCloudPath(
	string region,
	Guid projectGuid,
	Guid modelGuid
)
```

## Parameters
- **region** (`System.String`) - The region of the BIM 360 Docs or Autodesk Docs account and project which contains this model.
 Please see the reference values, like CloudRegionUS and CloudRegionEMEA ,
 and the new regions from release note.
- **projectGuid** (`System.Guid`) - The GUID of the cloud project which contains the model.
- **modelGuid** (`System.Guid`) - The GUID of the Revit cloud model.

## Returns
The cloud model path.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.CentralModelException** - The cloud project is missing.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - The central server could not be reached.
- **Autodesk.Revit.Exceptions.RevitServerUnauthenticatedUserException** - You must sign in to Autodesk 360 in order to complete action.
- **Autodesk.Revit.Exceptions.RevitServerUnauthorizedException** - You are unauthorized to access this resource.

