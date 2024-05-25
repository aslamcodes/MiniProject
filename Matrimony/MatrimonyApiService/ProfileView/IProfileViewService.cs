﻿namespace MatrimonyApiService.ProfileView;

/// <summary>
/// Interface for managing profile views.
/// </summary>
public interface IProfileViewService
{
    /// <summary>
    /// Adds a new view for a profile by a viewer asynchronously.
    /// </summary>
    Task AddView(int profileId, int viewerId);

    /// <summary>
    /// Adds a new view asynchronously.
    /// </summary>
    Task AddView(ProfileViewDto profileViewDto);

    /// <summary>
    /// Retrieves a view by its unique identifier asynchronously.
    /// </summary>
    Task<ProfileViewDto> GetViewById(int viewId);

    /// <summary>
    /// Deletes a view by its unique identifier asynchronously.
    /// </summary>
    Task DeleteViewById(int viewId);

    /// <summary>
    /// Deletes views older than the specified date asynchronously.
    /// </summary>
    Task DeleteOldViews(DateTime before);
}