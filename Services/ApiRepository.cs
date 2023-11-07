﻿using MedbaseLibrary.Models;
using System.Net.Http.Json;

namespace MedbaseLibrary.Services
{
    public class ApiRepository : IApiRepository 
    {
        private readonly HttpClient httpClient;

    public ApiRepository(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        public async Task<IEnumerable<Article>> GetArticlesNumbered(int num)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Article>>($"articles/select/{num}");
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Article>>("articles");
        }

        public async Task<Article> GetArticle(int id)
        {
            return await httpClient.GetFromJsonAsync<Article>($"/articles/{id}");
        }

        public async Task<IEnumerable<Topic>> GetTopics(string id)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Topic>>($"topics/{id}");
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Course>>($"courses");
        }

        public async Task<IEnumerable<Question>> GetQuestionsSimple(long id)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Question>>($"questions/{id}");
        }

        public async Task<QuestionPaged> GetPagedQuestions(int topic, int page, double numResults = 10f)
        {
            return await httpClient.GetFromJsonAsync<QuestionPaged>($"questions/{topic}/{numResults}/{page}");
        }
        public async Task<QuestionPaged> GetSearchPagedQuestions(int topic, int page, double numResults, string keyword)
        {
            return await httpClient.GetFromJsonAsync<QuestionPaged>($"questions/{topic}/{numResults}/{page}/{keyword}");
        }

        public async Task<IEnumerable<Topic>> GetAllTopics()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Topic>>("topics");
        }

        public async Task<Question> GetQuestion(int id)
        {
            return await httpClient.GetFromJsonAsync<Question>($"questions/select/{id}");
        }

        public async Task<Topic> GetTopic(int id)
        {
            return await httpClient.GetFromJsonAsync<Topic>($"topics/select/{id}");
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptions()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Subscription>>($"subscriptions");
        }

        public async Task<Subscription> GetSubscription(string email)
        {
            return await httpClient.GetFromJsonAsync<Subscription>($"subscriptions/{email}");
        }

        public async Task<Course> GetCourse(int id)
        {
            return await httpClient.GetFromJsonAsync<Course>($"courses/{id}");
        }
        public async Task<IEnumerable<Question>> GetAllQuestions()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Question>>($"questions");
        }

        public async void PostArticle(Article article)
        {
            await httpClient.PostAsJsonAsync($"articles/{article}", article);
        }

        public async void PostTopic(Topic topic)
        {
            await httpClient.PostAsJsonAsync($"topics/{topic}", topic);
        }

        public async void PostCourse(Course course)
        {
            await httpClient.PostAsJsonAsync($"courses/{course}", course);
        }
        public async void PostQuestion(Question question)
        {
            await httpClient.PostAsJsonAsync($"questions/{question}", question);
        }
        public async void PostSubscription(Subscription subscription)
        {
            await httpClient.PostAsJsonAsync($"subscriptions/{subscription}", subscription);
        }

        public async void DeleteCourse(int id)
        {
            await httpClient.DeleteAsync($"courses/{id}");
        }

        public async void DeleteQuestion(int id)
        {
            await httpClient.DeleteAsync($"questions/{id}");
        }

        public async void DeleteTopic(int id)
        {
            await httpClient.DeleteAsync($"topics/{id}");
        }

        public async void DeleteArticle(int id)
        {
            await httpClient.DeleteAsync($"articles/{id}");
        }

        public async void DeleteSubscription(int id)
        {
            await httpClient.DeleteAsync($"subscriptions/{id}");
        }

        public async void UpdateQuestion(int id, Question question)
        {
            await httpClient.PutAsJsonAsync($"questions/{id}", question);
        }

        public async void UpdateTopic(int id, Topic topic)
        {
            await httpClient.PutAsJsonAsync($"topics/{id}",topic);
        }

        public async void UpdateCourse(int id, Course course)
        {
            await httpClient.PutAsJsonAsync($"courses/{id}", course);
        }

        public async void UpdateArticle(int id, Article article)
        {
            await httpClient.PutAsJsonAsync($"articles/{id}",article);
        }
        public async void UpdateSubscription(int id, Subscription subscription)
        {
            await httpClient.PutAsJsonAsync($"subscriptions/{id}", subscription);
        }

        public async Task<CourseArticlesDto> GetCourseArticlesDto()
        {
            return await httpClient.GetFromJsonAsync<CourseArticlesDto>("/dashboard/getall");
        }

        public async Task<IEnumerable<Corrections>> GetCorrections()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Corrections>>($"corrections");
        }
        public async Task<IEnumerable<Question>> GetQuizQuestions(int topic, int number)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Question>>($"questions/quiz/{topic}/{number}");
        }
        public async Task<bool> PostCorrection(Corrections corrections)
        {
            var response = await httpClient.PostAsJsonAsync($"corrections/{corrections}", corrections);
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public async Task DeleteCorrection(int id)
        {
            await httpClient.DeleteAsync($"corrections/deleteone/{id}");
        }

        public async Task MergeCorrections()
        {
            await httpClient.PostAsync("corrections/mergeall", null);
        }

        public async Task ClearAllCorrection()
        {
            await httpClient.DeleteAsync("corrections/clearall");
        }
        
        public async Task<bool> MergeOneCorrection(int id)
        {
            bool isSuccessful = false;
            var response = await httpClient.PostAsJsonAsync($"corrections/mergeone/{id}", id);
            if (response.IsSuccessStatusCode)
                isSuccessful = true;
            return isSuccessful;
        }

        public async void PostUser(User user)
        {
            await httpClient.PostAsJsonAsync($"users/{user}", user);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await httpClient.GetFromJsonAsync<User>($"users/{username}");
        }

        public async Task<User> GetUserByUserGuid(string userGuid)
        {
            return await httpClient.GetFromJsonAsync<User>($"users/{userGuid}");
        }
    }
}
