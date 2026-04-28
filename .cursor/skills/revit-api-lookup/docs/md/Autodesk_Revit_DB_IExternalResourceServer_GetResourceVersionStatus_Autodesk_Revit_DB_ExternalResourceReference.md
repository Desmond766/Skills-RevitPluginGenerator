---
kind: method
id: M:Autodesk.Revit.DB.IExternalResourceServer.GetResourceVersionStatus(Autodesk.Revit.DB.ExternalResourceReference)
source: html/e5699493-c827-d7ba-151c-8d9cdbf894ba.htm
---
# Autodesk.Revit.DB.IExternalResourceServer.GetResourceVersionStatus Method

Implement this method to indicate whether the given version of a resource is the most
 current version of the data.

## Syntax (C#)
```csharp
ResourceVersionStatus GetResourceVersionStatus(
	ExternalResourceReference reference
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.ExternalResourceReference`) - The ExternalResourceReference to check.

## Returns
An enum indicating whether the resource is current, out of date, or of unknown status.

## Remarks
If Revit already has a version of this resource loaded, Revit will invoke this method
 to check whether the resource's data will change if LoadResource(Guid, ExternalResourceType, ExternalResourceReference, ExternalResourceLoadContext, ExternalResourceLoadContent) is called. If this method
 returns ResourceVersionStatus.Current, then Revit will improve model performance
 by not calling LoadResource(Guid, ExternalResourceType, ExternalResourceReference, ExternalResourceLoadContext, ExternalResourceLoadContent) . Note that this method may also be invoked to determine the behavior of certain
 elements within the user interface. For example, it may be used to warn the user if they
 are about to execute certain expensive operations (such as printing) with an outdated
 version of this resource. Servers which encounter errors should return ResourceVersionStatus.Unknown. Revit
 will reload resources whose version status is unknown, but will not display
 out-of-date warnings to the user on printing.

