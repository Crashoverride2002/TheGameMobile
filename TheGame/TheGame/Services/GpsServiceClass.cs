using System;
using System.Collections.Generic;
using System.Text;
using TheGame.Models;
using Xamarin.Essentials;

namespace TheGame.Services
{
    class GpsServiceClass
    {
        public GPSLock gps;
        /// <summary>
        /// Gets the coordinates based on maretime gps loc.
        /// </summary>
        /// <returns> GPSloc a public class of Model.</returns>
        public async System.Threading.Tasks.Task<GPSLock> getGPSCord()
        {
            try
            {
                GPSLock local = new GPSLock();
                var GPSCORD = await Geolocation.GetLastKnownLocationAsync();
                if (GPSCORD != null)
                {
                    local.Latitude = GPSCORD.Latitude;
                    local.Longitude = GPSCORD.Longitude;

                    if (GPSCORD.Course >= 350 || GPSCORD.Course == 360)
                        local.Direction = "N";
                    if (GPSCORD.Course < 350 && GPSCORD.Course >= 315)
                        local.Direction = "NW";
                    if (GPSCORD.Course == 270)
                        local.Direction = "W";
                    if (GPSCORD.Course > 180 && GPSCORD.Course < 270)
                        local.Direction = "SW";
                    if (GPSCORD.Course == 180)
                        local.Direction = "S";
                    if (GPSCORD.Course > 90 && GPSCORD.Course < 180)
                        local.Direction = "SE";
                    if (GPSCORD.Course == 90)
                        local.Direction = "E";
                    if (GPSCORD.Course > 0 && GPSCORD.Course < 90)
                        local.Direction = "NE";
                    return local;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                return null;
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                return null;
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                return null;
                // Handle permission exception
            }
            catch (Exception ex)
            {
                return null;
                // Unable to get location
            }

            return null;
        }
        /// <summary>
        /// / Gets the degrees and returns the navigation as well as the cource in degrees.
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<GPSDegrees> getCource()
        {
            try
            {
                GPSDegrees local = new GPSDegrees();
                var GPSCORD = await Geolocation.GetLastKnownLocationAsync();
                if (GPSCORD != null)
                {
                    local.course = (double)GPSCORD.Course;
                    if (GPSCORD.Course >= 350 || GPSCORD.Course == 360)
                        local.Direction = "N";
                    if (GPSCORD.Course < 350 && GPSCORD.Course >= 315)
                        local.Direction = "NW";
                    if (GPSCORD.Course == 270)
                        local.Direction = "W";
                    if (GPSCORD.Course > 180 && GPSCORD.Course < 270)
                        local.Direction = "SW";
                    if (GPSCORD.Course == 180)
                        local.Direction = "S";
                    if (GPSCORD.Course > 90 && GPSCORD.Course < 180)
                        local.Direction = "SE";
                    if (GPSCORD.Course == 90)
                        local.Direction = "E";
                    if (GPSCORD.Course > 0 && GPSCORD.Course < 90)
                        local.Direction = "NE";
                    return local;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                return null;
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                return null;
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                return null;
                // Handle permission exception
            }
            catch (Exception ex)
            {
                return null;
                // Unable to get location
            }

            return null;
        }
    }
}
